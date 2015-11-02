(function () {
    'use strict';

    angular
        .module('Kase')
        .factory('statusService', function () {
            var statusService = {};

            statusService.applyStatusLabel = function (item) {
                if (typeof item === 'object') {
                    if (item.ItemStatus.Name === "Pass") {
                        return 'label label-success';
                    };
                    if (item.ItemStatus.Name === "Fail") {
                        return 'label label-danger';
                    };
                    if (item.ItemStatus.Name === "Not run") {
                        return 'label label-info';
                    };
                    if (item.ItemStatus.Name === "Blocked") {
                        return 'label label-default';
                    };
                } else {
                    if (typeof item === 'string') {
                        if (item === "Pass") {
                            return 'label label-success';
                        };
                        if (item === "Fail") {
                            return 'label label-danger';
                        };
                        if (item === "Not run") {
                            return 'label label-info';
                        };
                        if (item === "Blocked") {
                            return 'label label-default';
                        };
                    }
                }
            }
            return statusService;
        });
})();