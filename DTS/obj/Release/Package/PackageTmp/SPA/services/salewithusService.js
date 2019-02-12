(function () {
    angular.module('app').service('salewithusService', ['$http', function ($http) {

        var self = this;

        //Service Function to Add Project Data Via AJAX call//
        self.AddSaleWithUs = function (salesUser) {

            return $http.post('api/SaleWithUs/AddSalesUser', salesUser)
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