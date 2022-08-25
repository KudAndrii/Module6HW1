import { useState } from "react";
import DeleteProduct from "../CrudRequests/DeleteProduct";
import { Button, Form } from "react-bootstrap";

type Input = {
    productId: { value: string };
};

const DeleteProductComponent = (): JSX.Element => {
    const [responseStatus, setResponseStatus] = useState<boolean>(false);

    return (
        <>
            <div>
                <Form
                    onSubmit={async (e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target & Input;
                        async function init() {
                            let id: number = Number(target.productId.value);
                            const result = await DeleteProduct(id);
                            setResponseStatus(result);
                        }

                        await init();
                    }}
                >
                    <Form.Group controlId="productId">
                        <Form.Label>
                            <i>Enter product id</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                    </Form.Group>
                    <Button variant="btn btn-primary active" type="submit">
                        Delete
                    </Button>
                </Form>
                <div>Response: {responseStatus}</div>
            </div>
        </>
    );
};

export default DeleteProductComponent;
