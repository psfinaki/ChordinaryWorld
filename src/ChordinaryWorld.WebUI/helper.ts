function chooseAuthority() {
    //const authority = "localhost:48213";
    //const authority = "chordinaryworld-test.azurewebsites.net";
    const authority = "chordinaryworld.azurewebsites.net";

    return authority;
}

function makeQueryHarmonies(artist: string, title: string) {
    const sanitizedArtist = encodeURIComponent(artist);
    const sanitizedTitle = encodeURIComponent(title);

    return `artist=${sanitizedArtist}&title=${sanitizedTitle}`;
}

function makeQueryTop(count: number) {
    return `count=${count}`;
}

function makeQueryArtistTop(artist: string) {
    const sanitizedArtist = encodeURIComponent(artist);
    return `artist=${sanitizedArtist}`;
}

function formatSuccess(harmonies: number) {
    return `Number of harmonies here is ${harmonies}.`;
}

function formatFailure(status: number): string {
    switch (status) {
        case 404:
            return "Chords to this song were not found.";
        case 400:
            return "Empty input is not allowed.";
        case 500:
            return "There is a problem with the chords found. This will be fixed soon."
        default:
            return "Something went wrong. Sorry for bad diagnostics!";
    }
}