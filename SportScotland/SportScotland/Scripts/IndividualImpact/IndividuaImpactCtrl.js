var app = angular.module("app", []);

app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
}]);

app.factory('httpOpertions', function ($http) {
    var httpFactory = {};
    //To get the individual impact record
    httpFactory.getImpactRecord = function (impactId) {
        var uri = window.location.host;
        var getImpactModel = [];
        var url = "http://" + uri + "/ImpactRecord/GetImpactRecord" + '/' + impactId;
        return $http.get(url);
    },
    //To save the individual impact record
    httpFactory.saveImpact = function (impactModel) {
        $http.post("../ImpactRecord/SaveImpactRecord", {
            impactRecord: impactModel
        }).then(function (response) {
            if (response.data === "Success") {
                window.location = "../Impact/GetAllImpacts";
            }
            else {
                alert('Unable to save data. Please contact administrator');
            }
        });
    }
    return httpFactory;
});

app.factory('dmOperations', function () {
    var dmFactory = {};
    //To add beneficiaries to $scope object
    dmFactory.add = function (item, $scope) {
        for (var i = 0; i < $scope.model.Benificiaries.length; i++) {
            if ($scope.model.Benificiaries[i].BenificiaryId === item) {
                $scope.model.AddedBenificiaries.push(
                    {
                        "BenificiaryId": $scope.model.Benificiaries[i].BenificiaryId,
                        "BenificiaryDescription": $scope.model.Benificiaries[i].BenificiaryDescription
                    });
            }
        }
    },
    //To remove beneficiaries from $scope object
    dmFactory.remove = function (item, $scope) {
        for (var i = 0; i < $scope.model.AddedBenificiaries.length; i++) {
            if ($scope.model.AddedBenificiaries[i].BenificiaryId === item) {
                $scope.model.AddedBenificiaries.splice(i, 1);
            }
        }
    }
    return dmFactory;
});

app.controller("impactRecordController", function ($scope, $http, httpOpertions, dmOperations) {
    $scope.model = [];
    var years = [2015, 2016, 2017, 2018];
    //declare default years to year dropdown
    $scope.startDateList = years;
    $scope.endDateList = years;
    //function to load bind record to $scope object
    var handleSuccess = function (data, status) {
        $scope.model = data;
        $scope.marginTop = $scope.getMargin();
        if ($scope.model.ImpactRecord === null || $scope.model.impactRecord === {}) {
            $scope.model.ImpactRecord =
                {
                    ImpactRecordId: 0,
                    Notes: "",
                    StartDate: 2015,
                    EndDate: 2015
                };
        }
        else {
            if ($scope.model.ImpactRecord.StartDate === null) {
                $scope.model.ImpactRecord.StartDate = 2015;
            }
            if ($scope.model.ImpactRecord.EndDate === null) {
                $scope.model.ImpactRecord.EndDate = 2015;
            }
        }
        if ($scope.model.AddedBenificiaries === null) {
            $scope.model.AddedBenificiaries = [];
        }
    }
    //function to handle error
    var handleError = function (response, status) {
        alert(response.message);
        return;
    }
    // get data
    var param = window.location.href.substring(window.location.href.lastIndexOf('/') + 1);
    var impactId = 0;
    if (!isNaN(param)) {
        impactId = param;
    }
    httpOpertions.getImpactRecord(impactId).success(handleSuccess).error(handleError);
    //update data
    $scope.update = function (impactId) {
        //check if others is chosen in drop down 
        if (impactId != 0) {
            httpOpertions.getImpactRecord(impactId).success(handleSuccess).error(handleError);
        }
        else {
            $scope.model.ImpactRecord =
                {
                    ImpactRecordId: 0,
                    Notes: "",
                    StartDate: 2015,
                    EndDate: 2015
                };
            $scope.model.AddedBenificiaries = [];
        }
    },
    //save data
    $scope.save = function () {
        if ($scope.model.ImpactId === 0 && ($scope.model.Others === '' || $scope.model.Others === undefined || $scope.model.Others === null)) {
            alert("Others Should not be empty");
            return;
        }
        if ($scope.model.ImpactRecord.StartDate > $scope.model.ImpactRecord.EndDate) {
            alert("Start Date should not be greater than Finish Date");
            return;
        }
        httpOpertions.saveImpact($scope.model);
    },
    //remove $scope data
    $scope.remove = function (item) {
        dmOperations.remove(item, $scope);
    },
    //add $scope data
    $scope.add = function (item) {
        for (var j = 0; j < $scope.model.AddedBenificiaries.length; j++) {
            if ($scope.model.AddedBenificiaries[j].BenificiaryId === item) {
                alert("Beneficiary already added in the list");
                return;
            }
        }
        dmOperations.add(item, $scope);
        $scope.marginTop = $scope.getMargin();
    }
    $scope.getMargin = function () {
        var rowHeight = 20;
        return ($scope.model.AddedBenificiaries.length * rowHeight) + "px"
    }
});