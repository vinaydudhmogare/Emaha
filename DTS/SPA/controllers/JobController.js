(function () {

    angular.module('app').controller('JobController', ['$scope', '$location', '$timeout', 'authService', 'jobService', function ($scope, $location, $timeout, authService, jobService) {

        $scope.Job = {
            Name:"",
            Email:"",
            Mobile:"",
            Qualification:"",
            Experience:"",
            Company_Name:"",
            Current_Salary: "",
            Area_of_Interest:""
           
        };
         
        //function to save Project data //
        $scope.saveDataJob = function (Job) {
            debugger;
            $scope.Job.Name = Job.Name;
            $scope.Job.Email = Job.Email;
            $scope.Job.Mobile = Job.Mobile;
            $scope.Job.Qualification = Job.Qualification;
            $scope.Job.Experience = Job.Experience;
            $scope.Job.Company_Name = Job.Company_Name;
            $scope.Job.Current_Salary = Job.Current_Salary;
            $scope.Job.Area_of_Interest = Job.Area_of_Interest;


            jobService.AddJob($scope.Job).then(function (response) {
                //  $window.location.reload();
                //$state.go("ProjectDetail");

            })
        }
    }]);

}())