"use strict";

var app = angular.module('fareCalculator', []);

app.controller('mainController', function ($scope, $http) {
    $scope.result = 0;
    $scope.fareInput = { MinutesAbove6mph: 0, MilesBelow6mph: 0, Date: '', Time: '' };
    $scope.getFare = function () {
        $http({
            method: 'POST',
            url: '/api/fare',
            data: $scope.fareInput
        }).
          success(function (data, status, headers, config) {
              var ret = data;
              $scope.result = data;
          }).
          error(function (data, status, headers, config) {
              alert(status);
          });
    };
});
