
var app = angular.module("MinutenApp", ['ngResource']);
//
app.controller("MinutenController", function ($scope, $log, EpisodeService) {

    $scope.sortColumn = "date";
    $scope.episodes = [];
    $scope.episodes = EpisodeService.query();

    $log.info($scope.episodes); // LOG
    
    $scope.updateEpisode = function (episode) {
        $log.info(episode);
        EpisodeService.update(episode);
    };

    
});


//angular.module("EpisodeService", []).factory("Episode", function ($resource) {
//    return $resource("/api/episodes/:id", { id: "@id" });
//})


app.factory("EpisodeService", function ($resource) {
    return $resource("/api/episodes/:id", { id: "@id" }, {
        update: {
            method:'PUT'
        }
    });
});
