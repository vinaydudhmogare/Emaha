(function () { 
 
    angular.module('app', ['ui.router',  'ngMaterial', 'ngAnimate', 'ngMessages', 'ui.bootstrap', 'angular-loading-bar', 'LocalStorageModule'])
   .run(run)

   .config(config);

    //#endregion

    //#region ams main Injector
    config.$inject = ['$urlRouterProvider', '$stateProvider', '$httpProvider'];
    //#endregion

    function config($urlRouterProvider, $stateProvider, $httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
        $urlRouterProvider.when('/Home', '/Home/ProjectEntryForm');
        $urlRouterProvider.otherwise('/login');

        $stateProvider
            .state('Home', {
                url: '/Home',
                templateUrl: 'SPA/partials/Home.html',
                controller: 'homeController'
            })

            .state('login', {
                url: '/login',
                templateUrl: 'SPA/partials/DefectTrackingSystem.html',
                controller: 'loginController'
            })
            .state('salewithus', {
                url: '/salewithus',
                templateUrl: 'SPA/partials/Home/Salewithus.html',
                controller: 'salewithusController',
               
            })

             .state('sellerProdDetails', {
                 url: '/sellerProdDetails',
                 templateUrl: 'SPA/partials/Home/SaleWithUsInnerPage1.html',
                 controller: 'salewithusController',

             })

             .state('sellerLocation', {
                 url: '/sellerLocation',
                 templateUrl: 'SPA/partials/Home/SaleWithUsInnerPage2.html',
                 controller: 'salewithusController',

             })

             .state('job', {
                url: '/job',
                templateUrl: 'SPA/partials/Home/Job.html',
                controller: 'signupController',
               
            })

               .state('ClientRequest', {
                   url: '/ClientRequest',
                   templateUrl: 'SPA/partials/Home/ClientRequest.html',
                   controller: 'signupController',

               })

            .state('Bags', {
                url: '/Bags',
                templateUrl: 'SPA/partials/Home/Bag.html',
                controller: 'BagController',

            })

               .state('Bottles', {
                url: '/Bottles',
                templateUrl: 'SPA/partials/Home/Bottles.html',
                controller: 'BottleController',

            })

              .state('Cap', {
                  url: '/Cap',
                  templateUrl: 'SPA/partials/Home/Cap.html',
                  controller: 'CapController',

              })


              .state('ProjectEntryForm', {
                  url: '/ProjectEntryForm',
                  templateUrl: 'SPA/partials/Home/ProjectEntryForm.html',
                  parent: 'Home',
                  controller:'projectController'
              })

                .state('ProjectDetail', {
                    url: '/ProjectDetail',
                    templateUrl: 'SPA/partials/Home/ProjectDetail.html',
                    parent: 'Home',
                    controller: 'projectController'
                })
                 .state('DefectEntry', {
                     url: '/DefectEntry/:id',
                     templateUrl: 'SPA/partials/Home/DefectEntry.html',
                     parent: 'Home',
                     controller: 'defectController'
                 })

                 .state('DefectDetail', {
                     url: '/DefectDetail',
                     templateUrl: 'SPA/partials/Home/DefectDetail.html',
                     parent: 'Home',
                     controller: "defectController"
                 })
    
    };

    run.$inject = ['authService'];

    function run(authService) {
        authService.fillAuthData();
    };
}());

