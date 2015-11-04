(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('testCaseController', ['$scope', 'TestCases', 'commService', 'statusService', function ($scope, TestCases, commService, statusService) {
        //Init
        $scope.testCases = TestCases.query({ id: '' });
        $scope.testCaseName = '';
        $scope.editedName = '';
        $scope.active = '';
        $scope.hidden = '';
        $scope.focused = '';
        $scope.editing = false;
        $scope.applyStatusLabel = function (id) {
            return statusService.applyStatusLabel(id);
        }
        
        // Get's the steps for a selected test case and sets the active (selected) test case in the View
        $scope.setActive = function (id) {
            $scope.active = id;
            commService.changeSteps(id);
        }

        $scope.update = function (id) {
            var item = (function () {
                for (var i = 0; i < $scope.testCases.length; i++) {
                    if ($scope.testCases[i].Id == id) {
                        return $scope.testCases[i];
                    }
                }
            })();

            item.Name = this.editedName;

            TestCases.put({ id: id }, JSON.stringify(item), function (response) {
                $scope.testCases.findIndex(function (obj, index) {
                    if (obj.Id == response.Id) {
                        this.testCases[index] = response;
                    }
                })
            });

            $scope.toggleEdit();
        }

        $scope.startEditing = function (id, name) {
            $scope.toggleEdit(id, name);
        }

        $scope.toggleEdit = function (id, name) {
            $scope.editedName = name;
            $scope.hidden = id;
            $scope.focused = id;
            if ($scope.editing) {
                $scope.editing = false;
            } else {
                $scope.editing = true;
            }
        }
        
        $scope.addTestCase = function () {
            if (this.testCaseName) {
                TestCases.post(JSON.stringify(this.testCaseName), function (response) {
                    // The TestController responds with the Id of the submitted test case
                    // so we can update the test cases in the $scope with
                    // the newly created test case
                    $scope.testCases.push(response);
                });
                this.testCaseName = '';
            }
        }

        //TODO: Make sure that test case statuses update along with steps

    }])
})();