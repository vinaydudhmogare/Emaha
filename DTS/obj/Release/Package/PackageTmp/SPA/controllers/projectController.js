(function () {
  
    angular.module('app').controller("projectController", ['$scope', 'projectService', '$window', '$http', '$state', function ($scope, projectService, $http, $state, $window) {

        $scope.Project = {};
        $scope.timezone = '';

//Object for Searching Sorting And Paging//
        $scope.pagingInfo = {
            search: '',
            page: 1,
            itemsPerPage: 5,
            reverse: false,
            totalItems: 0,
            sortBy: ''
        };



        //function to save Project data //
        $scope.SaveProject = function (Project) {               
            projectService.AddProject(Project).then(function (response) {
                $window.location.reload();
                $state.go("ProjectDetail");
              
            })
        }

        //function to open a new window pop up to add new project details\\
        $scope.openWindow = function () {
           
            window.open('#/Home/ProjectEntryForm', 'DefectTracking', 'width=500,height=400');
            $window.reload();
        }

        ////////////////////////


        //self calling function to get parent project list//
        projectService.GetParentProjectData().then(function (response) {
            $scope.ParentProjects = response.data;
        })

        //////////////////////////////
        //Function for searching//
        $scope.search = function () {
            $scope.pagingInfo.page = 1;
           
            loadProjects();
        };
       
        //function to give page number of paging//
        $scope.selectPage = function (page) {

            $scope.pagingInfo.page = page;

            loadProjects();
        };

       //function to perform sorting//
        $scope.sort = function (sortBy) {

            if (sortBy === $scope.pagingInfo.sortBy) {
              
                $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
            } else {
                $scope.pagingInfo.sortBy = sortBy;
                $scope.pagingInfo.reverse = false;
            }


            loadProjects();
        };

//function to load project on the loading of Porject detail page//
        function loadProjects() {
            // alert();
            $scope.Projects = null;
            projectService.GetFilteredData($scope.pagingInfo).then(function (response) {

                console.log(response.data);

                $scope.Projects = response.data;
                lo();
                //   $scope.pagingInfo.totalItems = response.data.length;
                //console.log()
            });
        }
        loadProjects();


        ///Get total Items//
        function lo() {
            projectService.GetParentProjectData().then(function (dataa) {
                $scope.pagingInfo.totalItems = dataa.data.length;
            })
        }


    }])

}())