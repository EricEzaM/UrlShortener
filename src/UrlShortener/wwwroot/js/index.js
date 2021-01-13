function shorten() {
    const url = document.getElementById("input").value

    fetch(`/shorten`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(url)
    })
    .then(async (res) => {
        const text = await res.text()
        if (res.ok) {
            updateResult(text)
            return
        }
        throw new Error(text)
    })
    .catch(err => handleError(err))
}

function updateResult(result) {
    const elem = document.getElementById("result")
    const link = window.location.href + result
    elem.innerText = link
    elem.setAttribute("href", link)
}

function handleError(error) {
    const elem = document.getElementById("result")
    elem.innerText = error
    elem.removeAttribute("href")
}