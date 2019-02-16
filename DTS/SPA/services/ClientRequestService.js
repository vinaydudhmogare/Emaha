(function () {
    angular.module('app').service('ClientRequestService', ['$http', function ($http) {

        var self = this;

        //Service Function to Add Project Data Via AJAX call//
        self.AddClientRequest = function (ClientRequestUser) {

            return $http.post('api/ClientRequest/AddClientRequestUser', ClientRequestUser)
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