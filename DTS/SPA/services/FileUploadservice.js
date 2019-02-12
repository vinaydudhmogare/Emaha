(function () {


  angular.module('app').factory('uploadService', function ($http, $q) {
        return {
            uploadFiles: function ($scope) {
                         
                var request = {              
                    method: 'POST',
                    url: 'api/Defect/upload',
                    data: $scope.formdata,                                       
                    headers: {
                        'Content-Type': undefined
                    }
                };
                   
                // SEND THE FILES.
                return $http(request)
                    .then(
                    function (response) {
                        if (response.data == null) {
                            return $q.reject(response.data);
                        }
                        else {
                            return response.data;
                        }                            
                    },
                    function (response) {
                        return $q.reject(response.data);
                    }
                    );
            }

        };
    })
}())