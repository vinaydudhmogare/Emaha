(function () {
    "use strict";

    //#region authInterceptorService factory Declaration 
    angular.module("app").factory("authInterceptorService", InterceptorService);
    //#endregion

    //#region  authInterceptorService factory Injector
    InterceptorService.$inject = ['$q', '$location', 'localStorageService'];
    //#endregion

    //#region  authInterceptorService  Main factory
    function InterceptorService($q, $location, localStorageService) {

        var authInterceptorServiceFactory = {};

        var _request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        }

        var _responseError = function (rejection) {
            if (rejection.status === 401) {
                $state.go('Index');
            }
            return $q.reject(rejection);
        }

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        return authInterceptorServiceFactory;


    }
    //#endregion

}())