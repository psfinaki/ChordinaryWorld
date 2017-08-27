/// <reference path="helper.ts" />

function search(): void {
    $('#result').toggle(false);
    $('#progress').toggle(true);

    const artist = $('#artist').val();
    const title = $('#title').val();

    const url = makeUrl(artist, title);
    $.get(url)
        .done((response: number) => {
            const message = formatSuccess(response);
            $('#result').text(message);
        })
        .fail((response: JQueryXHR) => {
            const message = response.status == 400
                ? formatFailure(response.responseJSON.message)
                : "Something went wrong. Sorry for bad diagnostics!";

            $('#result').text(message);
        })
        .always(() => {
            $('#progress').toggle(false);
            $('#result').toggle(true);
        });
}

function searchIfEnter(e: JQueryKeyEventObject): void {
    const enterKeyCode = 13;
    if (e.keyCode == enterKeyCode) {
        search();
    }
}

$(() => {
    $('#search').click(search);

    // this is why keyup:
    // https://stackoverflow.com/questions/155188/trigger-a-button-click-with-javascript-on-the-enter-key-in-a-text-box#comment13009121_155263
    $('#artist').keyup(searchIfEnter);
    $('#title').keyup(searchIfEnter);

    $('#artist').focus();
});