(function () {
    'use strict';

    angular
        .module('Kase')
        .controller('testCaseController', testCaseController);

    testCaseController.$inject = ['$scope', 'TestCases'];

    function testCaseController($scope, TestCases) {
        var testCases = [];
        testCases = TestCases.query({ id: '' });

        $scope.getSteps = function (testCaseId) {
            //TODO get steps for TC id
            alert('Test case id: ' + testCaseId);
        };

        //TODO: Make sure that test case statuses update along with steps

        $scope.applyStatusLabel = function (tc) {
            if (tc.TestCaseStatus.Name === "Pass") {
                return 'label label-success';
            };
            if (tc.TestCaseStatus.Name === "Fail") {
                return 'label label-danger';
            };
            if (tc.TestCaseStatus.Name === "Not run") {
                return 'label label-info';
            };
            if (tc.TestCaseStatus.Name === "Blocked") {
                return 'label label-default';
            };
        };

        $scope.testCases = testCases;
    }
})();
