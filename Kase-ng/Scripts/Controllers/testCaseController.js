(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('testCaseController', ['$scope', 'TestCases', function ($scope, TestCases) {
        var updateTestCases = function () {
            return TestCases.query({ id: '' });
        }

        $scope.getSteps = function (testCaseId) {
            //TODO get steps for TC id
            alert('Test case id: ' + testCaseId);
        };

        $scope.addTestCase = function () {
            if (this.newTestCaseName) {
                //TestCases.post({ Name: this.newTestCaseName });
                TestCases.post({ Name: this.newTestCaseName }, function (result) {
                    $scope.testCases = updateTestCases(result);
                });
                this.newTestCaseName = '';
            }
        }


        $scope.newTestCaseName = '';

        //TODO: Make sure that test case statuses update along with steps

        $scope.applyStatusLabel = function (tc) {
            if (tc.ItemStatus.Name === "Pass") {
                return 'label label-success';
            };
            if (tc.ItemStatus.Name === "Fail") {
                return 'label label-danger';
            };
            if (tc.ItemStatus.Name === "Not run") {
                return 'label label-info';
            };
            if (tc.ItemStatus.Name === "Blocked") {
                return 'label label-default';
            };
        };

        $scope.testCases = updateTestCases();
    }])
})();