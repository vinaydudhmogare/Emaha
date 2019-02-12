(function () {

    angular.module('app').service('defectService', ['$http', function ($http) {
        var self = this;

        //Service method to save Defect Data//
        self.AddDefect = function (Defect) {
            return $http.post("api/Defect/AddDefect",Defect)
        }


        //Servcie method to get all the defect data//
        self.AllDefectCount = function () {
            
            return $http.get('api/Defect/TotalDefect')
        }

        //Service method to get Filtered data of Defect//
        self.GetFilteredDefectData = function (pagingInfo) {
            return $http.get("api/Defect/DefectList", { params: pagingInfo });
        }
        //Service Method to get Priority Data For Dropdown
        self.GetPriorityData = function () {
            return $http.get("api/priority/GetPriority");
        }

        //Service Method to get Status Data For Dropdown
        self.GetStatusData = function () {
            return $http.get("api/Status/GetStatus");
        }

        
    }])


}())