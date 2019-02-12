(function () {
    angular.module('app')
        .directive('myDirectory', ['$parse', function ($parse) {
          
            function link(scope, element, attrs) {
                var model = $parse(attrs.myDirectory);
                element.on('change', function (event) {
                    scope.data = [];    //Clear shared scope in case user reqret on the selection
                    model(scope, { file: event.target.files });

                });
            };

            return {
                link: link
            }
        }]).controller("defectController", ['$scope', '$stateParams', '$http', 'defectService', 'projectService', '$state', 'uploadService', function ($scope, $stateParams, $http, defectService, projectService, $state, uploadService) {

            ///////////////////////MULTIPLE FILE UPLOAD START/////////

            $scope.uploading = false;
            $scope.countFiles = '';
             $scope.data = []; //For displaying file name on browser
            $scope.formdata = new FormData();
            $scope.getFiles = function (file) {
                angular.forEach(file, function (value, key) {
                    $scope.formdata.append(key, value);
                    $scope.data.push({ FileName: value.name, FileLength: value.size });

                });
                //This line just shows you there is possible to
                //send in the extra parameter to the server.


                $scope.countFiles = $scope.data.length == 0 ? '' : $scope.data.length + ' files selected';
                $scope.$apply();
                $scope.formdata.append('countFiles', $scope.countFiles);

            };


            //function to upload file//

            var uploadFiles = function () {
             
                $scope.uploading = true;
                uploadService.uploadFiles($scope)
                    // then() called when uploadFiles gets back
                    .then(function (data) {
                        
                        // promise fulfilled
                        $scope.uploading = false;
                        if (data === data) {                          
                            alert("Done!!!")
                            $scope.formdata = new FormData();
                            $scope.data = [];
                            $scope.countFiles = '';
                            $scope.$apply;
                            $scope.name = data;                        
                            $scope.OriginalFileName = data;

                            $state.go("DefectDetail")
                        } else {
                            //Server Error
                            alert("FAILED TO UPLOAD!!! " + data);
                        }
                    }, function (error) {
                        $scope.uploading = false;
                        //Server Error
                        alert("FAILED TO UPLOAD!!! " + error);
                    }

                    );
            };



            ////////////////////////MULTIPLE FILE UPLOAD END/////////////////S



        var ID = $stateParams.id
        $scope.Defect = {};
         
//Object for filtering the data//
        $scope.pagingInfo = {
            search: '',
            page: 1,
            itemsPerPage: 5,
            reverse: false,
            totalItems: 0,
            sortBy: ''
        };


        //function to save defect data//
        $scope.SaveDefect = function (Defect) {
            defectService.AddDefect(Defect).then(function (response) {
                //fetch the id from DefecController.cs//
                console.log(response.data)
                $scope.DefectID = response.data;
                uploadFiles();
               
            })
        }


       //logic to show seleted project on drop down in which we want to show our Project in defect entry form//
        projectService.GetParentProjectData().then(function (response) {
         
            if (ID === "") {
                
            $scope.ParentProjects = response.data;
           }
           else {
               angular.forEach(response.data, function (temp) {
      
                   if (temp.ID == ID) {
                       $scope.ParentProjects = response.data;
                       $scope.Defect.ProjectID = temp.ID;
                   }
               })
           }

        })

///////////////////////////////////////////////////////////////

        //function to search data of defect//
        $scope.search = function () {
            $scope.pagingInfo.page = 1;

            loadDefects();
        };

        //function to give new page number of paging//
        $scope.selectPage = function (page) {

            $scope.pagingInfo.page = page;

            loadDefects();
        };

        //function to perform sorting//
        $scope.sort = function (sortBy) {

            if (sortBy === $scope.pagingInfo.sortBy) {

                $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
            } else {
                $scope.pagingInfo.sortBy = sortBy;
                $scope.pagingInfo.reverse = false;
            }


            loadDefects();
        };

        //function to load project on the loading of Porject detail page//
        function loadDefects() {
        
            $scope.Projects = null;
            defectService.GetFilteredDefectData($scope.pagingInfo).then(function (response) {
           
                $scope.Defects = response.data;
                lo();

            });
        }
        loadDefects();


        ///Get total Items//
        function lo() {
            defectService.AllDefectCount().then(function (dataa) {
                $scope.pagingInfo.totalItems = dataa.data.length;
            })
        }



        // GetPriority List //
        defectService.GetPriorityData().then(function (response) {
            console.log(response.data)
            $scope.priority = response.data;
        })


            // GetStatus List //
        defectService.GetStatusData().then(function (response) {
            console.log(response.data)
            $scope.status= response.data;
        })
    }])
}())