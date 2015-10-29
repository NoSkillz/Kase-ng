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

        $scope.testCases = testCases;
    }
})();
