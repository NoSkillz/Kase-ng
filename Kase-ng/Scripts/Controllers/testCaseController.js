(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('testCaseController', ['$scope', 'TestCases', function ($scope, TestCases) {

        $scope.getSteps = function (testCaseId) {
            //TODO get steps for TC id
            alert('Test case id: ' + testCaseId);
        };

        $scope.addTestCase = function () {
            if (this.newTestCaseName) {
                TestCases.post({ Name: this.newTestCaseName }, function (response) {
                    // The TestController responds with the Id of the submitted test case
                    // so we can update the test cases in the $scope with
                    // the newly created test case
                    $scope.testCases.push(TestCases.get({ id: response.Id }));
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

        $scope.testCases = TestCases.query({ id: '' });
    }])
})();