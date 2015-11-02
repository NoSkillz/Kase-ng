(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('stepController', ['$scope', 'Steps', 'commService', 'statusService', function ($scope, Steps, commService, statusService) {
        //Init
        var activeTestCaseId = commService.testCaseId || '1';

        $scope.steps = Steps.query({ id: activeTestCaseId });
        $scope.stepName = '';
        $scope.applyStatusLabel = function (step) {
            return statusService.applyStatusLabel(step);
        }

        $scope.addStep = function () {
            if (this.stepName) {
                Steps.post({ id: activeTestCaseId }, JSON.stringify(this.stepName), function (response) {
                    $scope.steps.push(response);
                });
                this.stepName = '';
            }
        }

        var updateSteps = function () {
            $scope.steps = Steps.query({ id: activeTestCaseId });
        }

        $scope.$on('changeSteps', function () {
            activeTestCaseId = commService.testCaseId;
            updateSteps();
        });
    }])
})();