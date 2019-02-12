﻿(function () {

    angular.module('app').directive('fileuploaddirective', ['$parse', function ($parse) {
        debugger;
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

    }])
}())