(function () {
    'use strict';

    angular
        .module('Kase')
        .factory('stepService', stepService);

    var stepService = angular.module('stepService', ['ngResource']);
    stepService.factory('Steps', ['$resource',
        function ($resource) {
            return $resource('/Kase-ng/api/Step/:id', {}, {
                query: { method: 'GET', params: {}, isArray: true },
                get: { method: 'GET', params: {}, isArray: false },
                post: { method: 'POST', params: {}, isArray: false}
            }, { id: '@id' });
        }
    ]);
})();