(function () {
    angular.module('app').service('projectService', ['$http', function ($http) {

        var self = this;

        //Service Function to Add Project Data Via AJAX call//
        self.AddProject = function (Project) {

            return $http.post('api/Projects/AddProject',Project)
        }

        //Service function to get list of parent project//
        self.GetParentProjectData = function (Project) {

            return $http.get('api/Projects/GetParentProject', Project)
        }

        //Service function to get filtered  data of project//
        self.GetFilteredData = function (pagingInfo) {
            return $http.get("api/Projects/GetAllProject", { params: pagingInfo });
        }

    }]);

}());