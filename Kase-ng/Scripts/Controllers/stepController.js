(function () {
    'use strict';

    angular
        .module('Kase')
        .controller('stepController', stepController);

    stepController.$inject = ['$scope', 'Steps'];

    function stepController($scope, Steps) {
        var steps = [];
        steps = Steps.query({ id: '1' });
        $scope.steps = steps;
    }
})();
