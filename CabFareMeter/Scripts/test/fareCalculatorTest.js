"use strict";

describe("fareCalculator", function () {

    beforeEach(module('fareCalculator'));

    describe("mainController", function () {

        var scope, httpBackend, http;
        beforeEach(inject(function ($rootScope, $controller, $httpBackend, $http) {
            scope = $rootScope.$new();
            httpBackend = $httpBackend;
            http = $http;
            httpBackend.whenPOST("/api/fare").respond(function (method, url, data, headers) {
                return [200, 1, {}];
            });
            $controller("mainController", {
                $scope: scope,
                $http: http
            });
        }));

        it("Get Fare", function () {
            scope.fareInput = { MinutesAbove6mph: 5, MilesBelow6mph: 2, Date: '2010-10-08', Time: '5:30 PM' };
            scope.getFare();
            httpBackend.flush();
            expect(scope.result).toBe(1);
        });
    });
});