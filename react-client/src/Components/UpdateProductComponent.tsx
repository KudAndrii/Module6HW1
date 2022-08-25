import { useState } from "react";
import PutProduct from "../CrudRequests/PutProduct";
import { Button, Form } from "react-bootstrap";
import ProductModel from "../Models/ProductModel";

type Input = {
    product: {
        id: number;
        name: string;
        src: string;
        price: number;
        shortDescription: string;
        description: string;
    };
};

const UpdateProductComponent = (): JSX.Element => {
    const [responseStatus, setResponseStatus] = useState<number>(-1);

    return (
        <>
            <div>
                <Form
                    onSubmit={async (e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target & Input;
                        async function init() {
                            let product: ProductModel =
                                target.product as ProductModel;
                            const result = await PutProduct(product);
                            setResponseStatus(result);
                        }

                        await init();
                    }}
                >
                    <Form.Group controlId="product">
                        <Form.Label>
                            <i>Enter product id</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product name</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product src</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product price</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product shortDescription</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product description</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                    </Form.Group>
                    <Button variant="btn btn-primary active" type="submit">
                        Put
                    </Button>
                </Form>
                <div>Product was updated with next id: {responseStatus}</div>
            </div>
        </>
    );
};

export default UpdateProductComponent;
