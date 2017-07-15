/// <reference path="helper.ts" />

function search(): void {
    const artist = $('#artist').val();
    const title = $('#title').val();

    const url = makeUrl(artist, title);
    $.get(url)
        .done((result: number) => {
            const message = result != -1
                ? `Number of chords here is ${result}.`
                : "Chords to this song cannot be retrieved.";

            $('#answer').removeClass('hidden');
            $('#answer').text(message);
        });
}

function searchIfEnter(e: JQueryKeyEventObject): void {
    const enterKeyCode = 13;
    if (e.keyCode == enterKeyCode) {
        search();
    }
}

$(() => {
    $('#search').on('click', search);

    // this is why keyup:
    // https://stackoverflow.com/questions/155188/trigger-a-button-click-with-javascript-on-the-enter-key-in-a-text-box#comment13009121_155263
    $('#artist').on('keyup', searchIfEnter);
    $('#title').on('keyup', searchIfEnter);
});