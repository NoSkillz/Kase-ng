(function () {
    'use strict';

    var app = angular.module('Kase');

    app.controller('stepController', ['$scope', 'Steps', 'commService', 'statusService', function ($scope, Steps, commService, statusService) {
        //Init
        var activeTestCaseId = commService.testCaseId;
        var activeStepId;
        $scope.steps = Steps.query({ id: activeTestCaseId });
        $scope.stepName = '';
        $scope.active = '';

        $scope.applyStatusLabel = function (id) {
            return statusService.applyStatusLabel(id);
        }

        $scope.addStep = function () {
            if (this.stepName) {
                Steps.post({ id: activeTestCaseId }, JSON.stringify(this.stepName), function (response) {
                    $scope.steps.push(response);
                });
                this.stepName = '';
            }
        }

        $scope.setActive = function (id) {
            $scope.active = id;
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