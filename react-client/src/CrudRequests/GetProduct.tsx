import { appConfig } from "../apiConfig";
import ProductModel from "../Models/ProductModel";

const GetProduct = async (id: number): Promise<ProductModel> => {
    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products/${id}`,
        { headers: { "Access-Control-Allow-Origin": "*" } }
    );
    const body = await result.json();
    debugger;
    const product = body as ProductModel;
    console.log(product);
    return product;
};

export default GetProduct;
