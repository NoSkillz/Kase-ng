(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('testCaseController', ['$scope', 'TestCases', 'commService', 'statusService', function ($scope, TestCases, commService, statusService) {
        //Init
        $scope.testCases = TestCases.query({ id: '' });
        $scope.testCaseName = '';
        $scope.active = '';
        $scope.applyStatusLabel = function (id) {
            return statusService.applyStatusLabel(id);
        }
        
        // Get's the steps for a selected test case and sets the active (selected) test case in the View
        $scope.setActive = function (id) {
            $scope.active = id;
            commService.changeSteps(id);
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