(function () {

    angular.module('app').controller('salewithusController', ['$scope', '$location', '$timeout', 'authService', 'salewithusService', function ($scope, $location, $timeout, authService, salewithusService) {

        //alert('ok');

        $scope.salewithus = {
            Name: "",
            EmailId: "",
            Password: "",
            Mobile:""
        };

        //function to save Project data //
        $scope.saveDataSaleWithUs = function (salewithus) {
            debugger;
            $scope.salewithus.Name = salewithus.Name;
            $scope.salewithus.EmailId = salewithus.EmailId;
            $scope.salewithus.Password = salewithus.Password;
            $scope.salewithus.Mobile = salewithus.Mobile;


            salewithusService.AddSaleWithUs($scope.salewithus).then(function (response) {
              //  $window.location.reload();
                //$state.go("ProjectDetail");

            })
        }

    }]);

}())