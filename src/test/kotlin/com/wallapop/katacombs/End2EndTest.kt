package com.wallapop.katacombs

import com.fasterxml.jackson.databind.ObjectMapper
import com.wallapop.katacombs.application.Player
import com.wallapop.katacombs.application.PlayerRequest
import io.restassured.RestAssured
import io.restassured.http.ContentType
import org.apache.http.HttpStatus
import org.hamcrest.CoreMatchers.equalTo
import org.junit.jupiter.api.Test
import org.springframework.boot.test.context.SpringBootTest

@SpringBootTest(
        webEnvironment = SpringBootTest.WebEnvironment.DEFINED_PORT,
        classes = [KatacombsApplication::class]
               )
class End2EndTest {

    @Test
    fun `should start application`() {

    }

    @Test
    fun `should describe player room info`() {
        val createRequest = Player("F71B21F0-96BC-11EA-AB12-0800200C9A66", "Gerard")
        shouldCreatePlayer(createRequest)

        shouldDescribePlayerRoom(createRequest)
    }

    private fun shouldDescribePlayerRoom(player: Player) {
        RestAssured.given().get("/katacomb/player/" + player.sid)
                .then()
                .body(equalTo("""{"description" : "room direction description",
                        "items": []}"""))
                .statusCode(HttpStatus.SC_OK)
    }

    private fun shouldCreatePlayer(player: Player) {
        RestAssured.given()
                .contentType(ContentType.JSON)
                .body(ObjectMapper().writeValueAsString(PlayerRequest(player)))
                .post("/katacomb/player")
                .then()
                .statusCode(HttpStatus.SC_CREATED)
    }

}
