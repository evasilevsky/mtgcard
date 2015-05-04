var app = angular.module('MagicApp', []);

app.controller('DraftController', ['$scope', '$http', function ($scope, $http) {
	var getNextPack = function () {
		$http.get('/api/draft/getRandomPack')
			.success(function (data, status, headers, config) {
				$scope.currentPack = data.Cards;
			})
			.error(function (data, status, headers, config) {

			});
	};

	var takeCardFromPack = function(player, card, $index) {
		$http.get("/api/draft/takeCardFromPack?playerId=" + player.Id + "&cardId=" + card.CardId)
			.success(function(data, status, headers, config) {
				$scope.currentPack = data.Cards;
				$scope.draftedCards.push(card);
				$scope.currentPack.splice($index, 1);
			})
			.error(function(data, status, headers, config) {

			});
	};

	var getDraft = function(player, card, $index) {
		$http.get("/api/draft/getdraft")
			.success(function(data, status, headers, config) {
				$scope.draft = data;
				console.log(data);
			})
			.error(function(data, status, headers, config) {

			});
	};

	$scope.getState = function() {

	};
	$scope.draftedCards = [];
	$scope.currentPack = getNextPack();
	$scope.getNextPack = getNextPack;
	$scope.takeCardFromPack = takeCardFromPack;
	getDraft();
}]);