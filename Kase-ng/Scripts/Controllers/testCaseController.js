(function () {
    'use strict';

    angular
        .module('Kase')
        .controller('testCaseController', testCaseController);

    testCaseController.$inject = ['$scope', 'TestCases']; 

    function testCaseController($scope, TestCases) {
        $scope.testCases = TestCases.query({ id: '' });
        $scope.GetSteps = function (id) {
            alert(id);
        }
    }
})();
