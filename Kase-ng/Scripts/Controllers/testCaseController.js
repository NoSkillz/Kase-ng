(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('testCaseController', ['$scope', 'TestCases', 'commService', 'statusService', function ($scope, TestCases, commService, statusService) {
        //Init
        $scope.testCases = TestCases.query({ id: '' });
        $scope.testCaseName = '';
        $scope.applyStatusLabel = function (tc) {
            return statusService.applyStatusLabel(tc);
        }

        
        $scope.getSteps = function (testCaseId) {
            commService.changeSteps(testCaseId);
        };
        
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