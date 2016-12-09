var app = angular.module("MinutenApp", []);

app.controller("MinutenController", function ($scope, $http, $log) {

    $scope.episodes = [];
    $scope.loading = false;
    
    $scope.listEpisodes = function () {

        $scope.episodes = [];
        $http.get("/api/episodes")
        .success(function (data, status, headers, config) {
            $scope.episodes = data;
            $scope.loading = false;
            
            $log.info(data);
            $log.info(status);
            $log.info(headers);
        })
        .error(function (data, status, headers, config) {
            $scope.loading = false;
            console.log("API ERROR!");
        });
    };

});