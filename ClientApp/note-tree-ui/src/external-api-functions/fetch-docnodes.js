const URI = 'https://localhost:44308'

export const getAll = async () => {
    const response = await fetch(URI + '/getAll' )
    const responseJSON = await response.json()
    console.log(responseJSON)
    return responseJSON
}

export const getNodeById = async (id) => {
    const response = await fetch(URI + '/getById/' + id )
    const responseJSON = await response.json()
    console.log(responseJSON)
    return responseJSON
}

export const getTreeByDocId = async (id) => {
    const response = await fetch(URI + '/getByDocId/' + id )
    const responseJSON = await response.json()
    console.log(responseJSON)
    return responseJSON
}

export const editNode = async (data) => {
    await fetch(URI + '/editNode/' + data.id, {
        headers: {'Content-Type': 'application/json',},
        method: "PUT",
        body: JSON.stringify(data)
    })
    return null
}


// TEST THIS
export const addNode = async (data) => {
    const response = await fetch(URI + '/add/' + data.documentId, {
        headers: {'Content-Type': 'application/json',},
        method: "POST",
        body: JSON.stringify(data)
    })
    return response
}

// TEST THIS
export const deleteNode = async (id) => {
    const response = await fetch(URI + '/api/DocNodes/' + id, {
        method: "DELETE"
    })
    return response
}