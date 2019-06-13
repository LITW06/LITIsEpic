$(function () {
    $("body").jrumble({
        x: 2,
        y: 2,
        rotation: 1
    });
    var isRumbling = false;
    $(".meme").on('click', function () {
        if (!isRumbling) {
            $("body").trigger('startRumble');
            isRumbling = true;
        } else {
            $("body").trigger('stopRumble');
            isRumbling = false;
        }
    });
});