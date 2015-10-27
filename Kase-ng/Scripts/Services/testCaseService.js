(function () {
    'use strict';

    angular
        .module('Kase')
        .factory('testCaseService', testCaseService);

    var testCaseService = angular.module('testCaseService', ['ngResource']);
    testCaseService.factory('TestCases', ['$resource',
        function ($resource) {
            return $resource('/Kase-ng/api/TestCase/', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }
    ]);
})();