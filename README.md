BinaryStringReverse
===================

August 19 2021 - Received this test and this is the description. It had two questions total time I think was 45 minutes. Only one answer
is shown here because I didn't get to the other question.

Requirement was. Given a binary string find the largest substring with the same number of 0 and 1s
a good binary is a binary value with the same number of 0's and 1's and starts with 1. 
For example 10 and 1100 and 1010 and 10001110.
Next find another good binary directly next to that sub string and swap it if the the total binary
value is larger than the orginal

Take the value.  "11011000". The largest good string inside that starts with 1 this is 110[1100]0
the next adjacent good substring is 1[10][1100]0 and swapping them would be 1[1100][10]0
"11100100" and "11100100" > "1101100" so return "11100100"

Then the value has to be larger that the original value.