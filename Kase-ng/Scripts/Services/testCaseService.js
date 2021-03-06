﻿(function () {
    'use strict';

    angular
        .module('Kase')
        .factory('testCaseService', testCaseService);

    var testCaseService = angular.module('testCaseService', ['ngResource']);
    testCaseService.factory('TestCases', ['$resource',
        function ($resource) {
            return $resource('/Kase-ng/api/TestCase/:id', {}, {
                query: { method: 'GET', params: {}, isArray: true },
                get: { method: 'GET', params: {}, isArray: false },
                post: { method: 'POST', params: {}, isArray: false},
                put: { method: 'PUT', params: {}, isArray: false}
            }, { id: '@id' });
        }
    ]);
})();