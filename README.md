# Login with SHA-256

This project is a simple implementation of a login system that uses the SHA-256 algorithm for password hashing. It demonstrates how to securely store and verify user passwords using SHA-256 in a C# application.

## Features

- User registration with SHA-256 password hashing
- User login with password verification
- Secure password storage


### Prerequisites

- .NET Framework or .NET Core SDK installed on your machine
- Visual Studio or any other C# IDE


## Usage

1. Register a new user by providing a username and password.
2. The password will be hashed using SHA-256 and stored securely.
3. To login, provide the same username and password.
4. The application will hash the entered password and compare it with the stored hash to verify the login.

## SHA-256 Algorithm

SHA-256 (Secure Hash Algorithm 256-bit) is a cryptographic hash function that takes an input (or message) and produces a fixed-size, 256-bit (32-byte) hash value. It is one of the most widely used hash functions in cryptography and is part of the SHA-2 family of algorithms, designed by the National Security Agency (NSA).

### Key Characteristics of SHA-256:

- **Deterministic**: The same input will always produce the same hash output.
- **Fixed Size**: The output is always 256 bits long, regardless of the input size.
- **Fast Computation**: Efficiently computes the hash value for any given input.
- **Pre-image Resistance**: It is computationally infeasible to reverse the hash value to find the original input.
- **Collision Resistance**: It is computationally infeasible to find two different inputs that produce the same hash value.

### How SHA-256 Works:

1. **Padding**: The input message is padded so that its length is congruent to 448 modulo 512. Padding is always added, even if the input length is already congruent.
2. **Parsing**: The padded message is parsed into 512-bit blocks.
3. **Initialization**: The hash values are initialized to specific constant values.
4. **Processing**: Each 512-bit block is processed through 64 rounds of compression functions, updating the hash values.
5. **Output**: The final hash values are concatenated to produce the 256-bit hash output.

https://github.com/user-attachments/assets/59012f2c-0d4c-4a6f-8b21-f7cd0bc0d675


