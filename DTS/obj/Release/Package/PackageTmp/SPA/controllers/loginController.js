(function () {
    'use strict';
    angular.module('app').controller('loginController', ['$scope', '$state', 'authService', function ($scope, $state, authService) {
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";
//function to login user///
        $scope.login = function () {
            authService.login($scope.loginData).then(function (response) {
                $state.go('ProjectEntryForm');             
            },
             function (err) {
                 $scope.message = err.error_description;
             });
                  };
    }]);
}())