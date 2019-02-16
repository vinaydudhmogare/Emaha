(function () {

    angular.module('app').controller('ClientRequestController', ['$scope', '$location', '$timeout', 'authService', 'ClientRequestService', function ($scope, $location, $timeout, authService, ClientRequestService) {

        $scope.ClientRequest = {
            //Name: "",
            //Email: "",
            //Mobile: "",
            //Qualification: "",
            //Experience: "",
            //Company_Name: "",
            //Current_Salary: "",
            //Area_of_Interest: ""

        };
        debugger;
        //function to save ClientRequest data //
        $scope.saveDataClientRequest = function (ClientRequest) {
            debugger;
            //$scope.ClientRequest.Name = ClientRequest.Name;
            //$scope.ClientRequest.Email = ClientRequest.Email;
            //$scope.ClientRequest.Mobile = ClientRequest.Mobile;
            //$scope.ClientRequest.Qualification = ClientRequest.Qualification;
            //$scope.ClientRequest.Experience = ClientRequest.Experience;
            //$scope.ClientRequest.Company_Name = ClientRequest.Company_Name;
            //$scope.ClientRequest.Current_Salary = ClientRequest.Current_Salary;
            //$scope.ClientRequest.Area_of_Interest = ClientRequest.Area_of_Interest;


           ClientRequestService.AddClientRequest($scope.ClientRequest).then(function (response) {
                //  $window.location.reload();
                //$state.go("ProjectDetail");

            })
        }
    }]);

}())