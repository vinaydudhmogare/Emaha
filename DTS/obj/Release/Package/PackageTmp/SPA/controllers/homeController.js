(function () {

    angular.module('app')
      .controller('homeController', ['$scope', '$state', 'authService', function ($scope, $state, authService) {

          $scope.$state = $state;

          if (!authService.authentication.isAuth) {
              $state.go('login')
          }
    //Function to logout user ///
          $scope.logout = function () {
              authService.logOut();

              $state.go('login')
          }

          $scope.authentication = authService.authentication;

      }]);
   



}())