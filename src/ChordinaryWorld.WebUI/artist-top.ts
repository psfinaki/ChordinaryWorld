/// <reference path="helper.ts" />

module ArtistTop {
    function search(): void {
        $('#result').addClass("invisible");
        $('#progress').removeClass("invisible");

        const artist = $('#artist').val();

        const query = makeQueryArtistTop(artist);
        const url = makeUrl("artisttop", query);
        $.get(url)
            .done((response: [string, number][]) => {
                $('#top').removeClass("invisible");
                $.each(response, (key, item: any) => {
                    $('#result').toggle();
                    $('#progress').toggle();

                    function formatTopLine(item: [string, number]) {
                        return `${item[0]} - ${item[1]}`;
                    }

                    // for some reason, it does not work directly
                    const itemDTO: [string, number] = [item.item1, item.item2];
                    $('<li>', { text: formatTopLine(itemDTO) }).appendTo($('#topList'));
                });
            })
            .fail((response: JQueryXHR) => {
                const message = formatFailure(response.status);
                $('#result').text(message);
            })
            .always(() => {
                $('#progress').addClass("invisible");
                $('#result').removeClass("invisible");
            });
    }

    $(() => {
        $('#search').click(search);

        // this is why keyup:
        // https://stackoverflow.com/questions/155188/trigger-a-button-click-with-javascript-on-the-enter-key-in-a-text-box#comment13009121_155263
        $('#artist').keyup({ searcher: search }, searchIfEnter);

        $('#artist').focus();
    });
}