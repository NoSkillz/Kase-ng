(function () {
    "use strict";

    angular
        .module('Kase')
        .factory('commService', function ($rootScope) {
            var commService = {};

            commService.testCaseId = '';

            commService.changeSteps = function (testCaseId) {
                if (testCaseId !== this.testCaseId) {
                    this.testCaseId = testCaseId;
                    this.broadcast('changeSteps')
                }
            }

            commService.broadcast = function (message) {
                $rootScope.$broadcast(message);
            }

            return commService;
        }
    )
})();