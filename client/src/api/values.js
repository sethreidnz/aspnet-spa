import ApiConfig from './apiConfig'
const valuesEndpoint = `${ApiConfig.host}/api/values`

export const getValues = async () => {
    var response = await fetch(valuesEndpoint)
    return await response.json()
}