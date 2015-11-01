(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('stepController', ['$scope', 'Steps', function ($scope, Steps) {
        var steps = [];
        steps = Steps.query({ id: '1' });
        $scope.steps = steps;
    }])
})();