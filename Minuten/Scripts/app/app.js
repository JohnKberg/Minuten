
var app = angular.module("MinutenApp", ['ngResource', 'ui.bootstrap']);
//
app.controller("MinutenController", function ($scope, $log, EpisodeService, PanelMemberService) {

    $scope.sortColumn = "date";
    $scope.episodes = [];
    $scope.episodes = EpisodeService.query();
    $scope.pmembers = PanelMemberService.query();

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


app.factory("PanelMemberService", function ($resource) {
    return $resource("/api/panelmembers/:id", { id: "@id" }, {
        update: {
            method: 'PUT'
        }
    });
});