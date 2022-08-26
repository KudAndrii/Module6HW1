import { useState } from "react";
import PutProduct from "../CrudRequests/PutProduct";
import { Button, Form } from "react-bootstrap";
import ProductModel from "../Models/ProductModel";
import { Input } from "../Types/Types";

const UpdateProductComponent = (): JSX.Element => {
    const [responseStatus, setResponseStatus] = useState<number | undefined>(
        undefined
    );

    return (
        <>
            <div>
                <Form
                    onSubmit={async (e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target & Input;
                        async function init() {
                            let product: ProductModel =
                                new Object() as ProductModel;
                            product.productId = Number(target.productId.value);
                            product.name = target.name.value;
                            product.src = target.src.value;
                            product.price = Number(target.price.value);
                            product.shortDescription =
                                target.shortDescription.value;
                            product.description = target.description.value;
                            const result = await PutProduct(product);
                            setResponseStatus(result);
                        }

                        await init();
                    }}
                >
                    <Form.Group controlId="productId">
                        <Form.Label>
                            <i>Enter product id</i>
                        </Form.Label>
                        <Form.Control name="productId"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="name">
                        <Form.Label>
                            <i>Enter product name</i>
                        </Form.Label>
                        <Form.Control name="name"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="src">
                        <Form.Label>
                            <i>Enter product src</i>
                        </Form.Label>
                        <Form.Control name="src"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="price">
                        <Form.Label>
                            <i>Enter product price</i>
                        </Form.Label>
                        <Form.Control name="price"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="shortDescription">
                        <Form.Label>
                            <i>Enter product shortDescription</i>
                        </Form.Label>
                        <Form.Control name="shortDescription"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="description">
                        <Form.Label>
                            <i>Enter product description</i>
                        </Form.Label>
                        <Form.Control name="description"></Form.Control>
                    </Form.Group>

                    <Button variant="btn btn-primary active" type="submit">
                        Put
                    </Button>
                </Form>
                <div>
                    Product was updated with next id:{" "}
                    {responseStatus === undefined
                        ? ""
                        : responseStatus.toString()}
                </div>
            </div>
        </>
    );
};

export default UpdateProductComponent;
