mergeInto(LibraryManager.library, {
  InitPurchases: function() {
    initPayments();
  },

  Purchase: function(id) {
    buy(id);
  },

  AuthenticateUser: function() {
    auth();
  },

  GetUserData: function() {
    getUserData();
  },

  ShowFullscreenAd: function () {
    showFullscrenAd();
  },

  ShowRewardedAd: function(placement) {
    showRewardedAd(placement);
    return placement;
  },

  OpenWindow: function(link){
    var url = Pointer_stringify(link);
      document.onmouseup = function()
      {
        window.open(url);
        document.onmouseup = null;
      }
  },

  GetLang: function () {
    var lang = sdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },
  Review: function () {
    ShowReview();
  },

SetLeaderBoard: function(score){
    SetLeaderBoard(score);
  }
});