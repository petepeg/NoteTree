const URI = 'https://localhost:44308'
const endpoint = '/api/Documents/'

export const createDocument = async () => {
    const response = await fetch(URI + endpoint)
    const responseJSON = await response.json()
    console.log(responseJSON)
    return responseJSON
}

 export const getLatestDocument = async () => {
    const response = await fetch(URI + endpoint, 
        {
            method: 'POST', 
            headers: {'Content-Type': 'application/json'}, 
        })
    const responseJSON = await response.json().catch( error => { console.log('caught', error.message)} )
    console.log(responseJSON)
    return responseJSON
 } 

 export const getDocumentById = async (id ) => {
    const response = await fetch(URI + endpoint + id)
    const responseJSON = await response.json()
    console.log(responseJSON)
    return responseJSON
}

export const updateDocumentById = async (data) => {
    await fetch(URI + endpoint + data.id, 
        {
            method: 'PUT',
            headers: {'Content-Type': 'application/json',},
            body: JSON.stringify(data)
        })
    return null
}

export const deleteDocumentById = async( id ) => {
    await fetch(URI + endpoint + id)
    return null
}

