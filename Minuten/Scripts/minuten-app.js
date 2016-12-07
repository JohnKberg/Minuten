var app = angular.module("MinutenApp", []);

app.controller("MinutenController", function ($scope, $http) {

    $scope.episodes = [];
    $scope.loading = false;
    console.log("CTOR - episodes len: " + $scope.episodes.length)

    $scope.listEpisodes = function () {

        $scope.episodes = [];
        $http.get("/api/episodes")
        .success(function (data, status, headers, config) {
            $scope.episodes = data;
            $scope.loading = false;
            console.log("API OK! episodes.len: " + $scope.episodes.length);
        })
        .error(function (data, status, headers, config) {
            $scope.loading = false;
            console.log("API ERROR!");
        });
    };

});